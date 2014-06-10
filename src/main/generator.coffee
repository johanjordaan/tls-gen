fs = require 'fs'

mkdirp = require 'mkdirp'

parser = require '../grammar/parser'
t2c  = require '../templates/template'

generate = (template,data,dest) ->
  res = t2c(data)
  fs.writeFile dest, res, 'utf8' , (err,data) ->
    if err?
      console.log err

fs.readFile "./grammar/rfc5246.txt",'utf8', (err,data) ->
  if err?
    console.log err
  else
    context = parser.parse(data)
    generate data, context, './lib/cs/TLS.cs'

