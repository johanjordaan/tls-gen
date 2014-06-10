should = require('chai').should()
expect = require('chai').expect

_ = require('underscore')

fs = require('fs')

parser = require('../grammar/parser')

describe 'parser', (done) ->
  context = {}
  before (done) ->
    fs.readFile "./grammar/rfc5246.txt",'utf8', (err,data) ->
      context = parser.parse(data)
      done()

  it 'should extract the correct number of enums from the protocol definition', ()->
    context.enums.length.should.equal 17

  it 'should extract the correct number of enums from the protocol definition', ()->
    _.keys(context.enums_by_name).length.should.equal 17


    #for e in context.enums
    #  console.log e.name 
    #console.log context.enums[0]


  it 'should extract the correct number of structs from the protocol definition', ()->
    context.structs.length.should.equal 41

  it 'should extract the correct number of structs from the protocol definition', ()->
    _.keys(context.structs_by_name).length.should.equal 41

    #for e in _.keys(context.structs_by_name)
    #  console.log e

