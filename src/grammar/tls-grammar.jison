

/* lexical grammar */
%lex

%options lex case-insensitive

%%
\s+                             /* skip whitespace */ 

";"                             return ';';
":"                             return ':';
"("                             return '(';
")"                             return ')';   
"{"                             return '{';
"}"                             return '}';
"["                             return '[';
"]"                             return ']';
"<"                             return '<';
">"                             return '>';
","                             return ',';
".."                            return '..'
"^"                             return '^'
"."                             return '.';

struct                          return 'STRUCT';
enum                            return 'ENUM';
select                          return 'SELECT';
case                            return 'CASE';

uint8                           return 'UINT8';
uint16                          return 'UINT16';  
uint24                          return 'UINT24'; 
uint32                          return 'UINT32'; 
opaque                          return 'OPAQUE';

"digitally-signed"              return 'DIGITALLY-SIGNED'; 
"stream-ciphered"               return 'STREAM-CIPHERED';
"block-ciphered"                return 'BLOCK-CIPHERED';
"aead-ciphered"                 return 'AEAD-CIPHERED';
"public-key-encrypted"          return 'PUBLIC-KEY-ENCRYPTED';

[a-zA-Z_][a-zA-Z0-9_]*          return 'CONSTANT';
[0-9]+                          return 'INTEGER';

"-"                             return '-';

[/][/].*(\n|<<EOF>>)                 /* skip comments */ 

/lex 

%start definitions


%% /* language grammar */


definitions
    : definitions definition
    | definition                    
    ;

definition
    : struct                { yy.add_struct($1); }    
    | enum                  { yy.add_enum($1); }        
    | field                 { yy.add_field($1); }           
    ;

struct 
    : STRUCT '{' struct_fields '}' name ';'    
        {
            $$ = { name:$5, fields:$3  }
        }                  
    | crypto_attribute STRUCT '{' struct_fields '}' name ';'
        {
            $$ = { name:$6, crypto_attribute:$1, fields:$4  }
        }
    | STRUCT '{' '}' name ';' 
        {
            $$ = { name:$4, fields:[]  }
        }                                   
    ;

anon_struct
    : STRUCT '{' struct_fields '}'
        {
            $$ = { fields:$3  }
        } 
    | crypto_attribute STRUCT '{' struct_fields '}'
        {
            $$ = { crypto_attribute:$1, fields:$4  }
        }
    | STRUCT '{' '}' 
        {
            $$ = { fields:[]  }
        }       
    ;


struct_fields 
    : struct_fields struct_field    { $1.push($2); }
    | struct_field                  { $$ = [$1]; }
    ;


struct_field
    : field
    | crypto_attribute field
    | anon_struct name ';'
        { 
            s = yy.add_struct($1); 
            $$ = {
                type    : { name:s.name },
                name    : s.name+"_instance",
                is_array: false    
            }
        }
    | anon_struct ';'
        { 
            s = yy.add_struct($1); 
            $$ = {
                type    : { name:s.name },
                name    : s.name+"_instance",
                is_array: false    
            }
        }
    | inline_enum name ';' 
        { 
            e = yy.add_enum($1); 
            $$ = {  
                type    : { name:e.name }, 
                name    : $2, 
                is_array: false
            };
        }  
    | select name ';'
        {
            $$ = {
                type        : { is_variant:true },
                selector    : $1.selector,               // The thing that will be checked
                cases       : $1.cases,
                name        : $2,
            };
        }
    | select ';'
        {
            $$ = {
                type        : { is_union:true },
                selector    : $1.selector,
                cases       : $1.cases
            };
        }
    ;    

field 
    : type name ';'
        { 
            $$ = { 
                type:$1,
                name:$2, 
                is_array:false 
            }
        }

    | type name '[' INTEGER ']' ';'
        { 
            $$ = { 
                type:$1, 
                name:$2, 
                is_array:true, 
                size:Number($4), 
            } 
        }

    | type name '[' struct_ref ']' ';'
        { 
            $$ = { 
                type:$1,
                name:$2,
                is_array:true,
                size_ref:$4 
            } 
        }

    | type name '<' INTEGER '..' INTEGER '>' ';'
        { 
            $$ = { 
                type:$1, 
                name:$2, 
                is_array:true, 
                floor:Number($4), 
                ceiling:Number($6) 
            } 
        }
    | type name '<' INTEGER '..' INTEGER '^' INTEGER '-' INTEGER '>' ';'
        { 
            $$ = { 
                type:$1, 
                name:$2, 
                is_array:true, 
                floor:Number($4), 
                ceiling: Math.pow(Number($6),Number($8))-Number($9) 
            } 
        }
    | type name '<' INTEGER '^' INTEGER '-' INTEGER '>' ';'
        { 
            $$ = { 
                type:$1, 
                name:$2, 
                is_array:true, 
                floor:0, 
                ceiling: Math.pow(Number($4),Number($6))-Number($8) 
            } 
        }
    ;

type 
    : base_type                                 { $$ = { name:$1, is_base:true }; }
    | name                                      { $$ = { name:$1 }; }
    ;

struct_ref
    : name '.' name                            
        {
            $$ = {
                source : $1,
                field : $3    
            }

        }             
    ;

select 
    : SELECT '(' struct_ref ')' '{' select_cases '}' 
        {
            $$ = {
                selector : $3,
                cases    : $6
            }
        }
    | SELECT '(' name ')' '{' select_cases '}' 
        {
            $$ = {
                selector : { field : $3 },
                cases    : $6
            }
        }
    ;

select_cases
    : select_cases select_case                  { $1.push($2); }
    | select_case                               { $$ = [$1]; }
    ;

select_case
    : CASE name ':' type ';'
        {
            $$ = {
                name        : $2,
                type        : $4 
            }
        }
    | CASE name ':' struct_fields
        {
            $$ = {
                name    : $2,
                fields  : $4 
            }
        }
    | CASE name ':' 
        {
            $$ = {
                name    : $2,
                default : true
            }
        }
    ;

enum 
    : ENUM '{' enum_fields '}' name ';'         {  $$ = { name:$5, values:$3 }; }
    ;

inline_enum 
    : ENUM '{' enum_fields '}'                  {  $$ = { values:$3 }; }
    ;

enum_fields 
    : enum_fields ',' enum_field                { $1.push($3); }
    | enum_field                                { $$ = [$1]}
    ;

enum_field
    : name '(' INTEGER ')'                      { $$ = { name:$1, value:$3 }; }
    | name                                      { $$ = { name:$1 }; }
    | '(' INTEGER ')'                           { $$ = { max_value:$2 }; }
    ;

name
    : CONSTANT
    ;

crypto_attribute
    : DIGITALLY-SIGNED
    | STREAM-CIPHERED
    | BLOCK-CIPHERED
    | AEAD-CIPHERED
    | PUBLIC-KEY-ENCRYPTED
    ;

base_type 
    : UINT8
    | UINT16
    | UINT24
    | UINT32
    | OPAQUE
    ;
