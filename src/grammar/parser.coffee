parser = require('./tls-grammar').parser;
_ = require('underscore')

class Enum
  @count : 0 
  constructor: (init) ->
    if init.name?
      @name = init.name
    else
      @name = "Enum_#{Enum.count}"
      Enum.count++  

    @max_value = 0  
    last_value = 0
    @values = {} 
    for value in init.values
      if value.max_value?
        @max_value = value.max_value
      else
        # If value is not defined then increment the last value
        if !value.value?
          last_value = last_value + 1
          value.value = last_value
        else
          last_value = value.value
        
        @values[value.name] = value.value  
        if value.value > @max_value
          @max_value = value

class Field
  constructor: (init) ->
    @type = init.type
    @name = init.name
    @is_array = init.is_array
    @crypto_attribute = init.crypto_attribute
    
    if init.size?
      @is_fixed_array = true
      @size = init.fixed_size
    else if init.size_ref?
      @is_fixed_array = false
      @size = init.size_ref
    else if init.floor?
      @is_fixed_array = false
      @floor = init.floor
      @ceiling = init.ceiling

class Struct
  @count : 0 
  constructor: (init) ->

    # Extract the name fro the structure. If it is anonymous then assign it a name
    #  
    if init.name?
      @name = init.name
    else
      @name = "Struct_#{Struct.count}"
      Struct.count++

    if init.crypto_attribute?
      @crypto_attribute = init.crypto_attribute

    @fields = []
    @fields_by_name = {}  
    for field in init.fields
      new_field = new Field(field)
      if new_field.type? && new_field.type.name?
        @fields.push new_field
        @fields_by_name[new_field.name] = new_field  

validate = (context) ->
  # 1) Check that all types that are referenced are defined
  #
  #for struct in context.structs
  #  for field in struct.fields
  #    if !field.type?
  #      console.log field,struct
  #    if field.type.is_base? && !field.type.is_base
  #      if !_.contains(_.keys(context.structs_by_name),field.type.name) && !_.contains(_.keys(context.enums_by_name),field.type.name)
  #        context.errors.push "undefined type : #{field.type.name} in #{struct.name}.#{field.name}"


parse = (text) ->
  context =
    enums : []
    enums_by_name : {}
    structs : []
    structs_by_name : {}
    errors : []
  
  methods = 
    add_enum : (e) ->
      new_enum = new Enum(e)
      context.enums.push new_enum
      context.enums_by_name[new_enum.name] = new_enum
    add_struct : (s) ->
      new_struct = new Struct(s)
      context.structs.push new_struct
      context.structs_by_name[new_struct.name] = new_struct
    add_field : (f) ->
      f_clone = _.clone(f)
      f_clone.name = 'data'

      s = 
        name : f.name
        fields : [f_clone]     

      @add_struct(s)  


  parser.yy = methods
  parser.parse(text)
  
  validate(context)

  return context

module.exports = 
  parse : parse