`// This file was generate from a template using t2c
 // Source file : src/templates/template.t2c 
 // `
template = (ctx) ->
  output = ''
  output += "using System;\n"
  output += "\n"
  output += "\n"
  output += "namespace TLS\n"
  output += "{\n"
  
  for e in ctx.enums
    z = []
    for v in e.values 
      z.push "tls_#{v.name}=#{v.value}"
  
    output += "  public enum #{e.name}Enum { #{z.join(',')} };\n"
    output += "  public class #{e.name}\n"
    output += "  {\n"
    output += "    public #{e.name}Enum value;\n"
    output += "    public int num_bytes = 1;\n"
    output += "\n"
    output += "    public int Load(byte[] buffer,int offset) {\n"
    output += "      var value = BufferTools.ReadNumberFromBuffer(buffer,offset,num_bytes);\n"
    output += "      if(Enum.IsDefined(typeof(#{e.name}Enum), value)) {\n"
    output += "        this.value = (#{e.name}Enum)value;\n"
    output += "      }\n"
    output += "      return num_bytes;\n"
    output += "    }\n"
  
  
    output += "  }\n"
    output += "\n"
  
  output += "}\n"
  
  
  
  
module.exports = template