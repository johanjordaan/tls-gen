fs = require 'fs'

ejs = require 'ejs'
mkdirp = require 'mkdirp'

parser = require '../grammar/parser'

generate = (template,data,dest) ->
  res = ejs.render(template,data)
  fs.writeFile dest, res, 'utf8' , (err,data) ->
    if err?
      console.log err

fs.readFile "./grammar/rfc5246.txt",'utf8', (err,data) ->
  if err?
    console.log err
  else
    context = parser.parse(data)
    fs.readFile './templates/template.cs','utf8', (err,data) ->
      if err?
        console.log err
      else
        mkdirp './lib/cs', (err) ->
          if err?
            console.log err
          else
            generate data, context, './lib/cs/tls.cs'

