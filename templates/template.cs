using System;

namespace TLS
{

  <% for(var si in structs) {  %>
  public class <%= structs[si].name %>
  {
    <% for(var fi in structs[si].fields) { -%>
    <%= structs[si].fields[fi].type.name %> <%= structs[si].fields[fi].name %>;  
    <% } %>
  }  
  <% } %>
}
