(function() {
  // This file was generate from a template using t2c
 // Source file : src/templates/template.t2c 
 // ;
  var template;

  template = function(ctx) {
    var e, output, v, z, _i, _j, _len, _len1, _ref, _ref1;
    output = '';
    output += "using System;\n";
    output += "\n";
    output += "\n";
    output += "namespace TLS\n";
    output += "{\n";
    _ref = ctx.enums;
    for (_i = 0, _len = _ref.length; _i < _len; _i++) {
      e = _ref[_i];
      z = [];
      _ref1 = e.values;
      for (_j = 0, _len1 = _ref1.length; _j < _len1; _j++) {
        v = _ref1[_j];
        z.push("tls_" + v.name + "=" + v.value);
      }
      output += "  public enum " + e.name + "Enum { " + (z.join(',')) + " };\n";
      output += "  public class " + e.name + "\n";
      output += "  {\n";
      output += "    public " + e.name + "Enum value;\n";
      output += "    public int num_bytes = 1;\n";
      output += "\n";
      output += "    public int Load(byte[] buffer,int offset) {\n";
      output += "      var value = BufferTools.ReadNumberFromBuffer(buffer,offset,num_bytes);\n";
      output += "      if(Enum.IsDefined(typeof(" + e.name + "Enum), value)) {\n";
      output += "        this.value = (" + e.name + "Enum)value;\n";
      output += "      }\n";
      output += "      return num_bytes;\n";
      output += "    }\n";
      output += "  }\n";
      output += "\n";
    }
    return output += "}\n";
  };

  module.exports = template;

}).call(this);
