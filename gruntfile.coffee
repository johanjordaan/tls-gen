module.exports = (grunt) ->

  grunt.initConfig
    pkg : grunt.file.readJSON('package.json')

    coffee: 
      build:
        expand: true,
        cwd: './src',
        src: ['**/*.coffee'],
        dest: './',
        ext: '.js'
        extDot : 'last'

    mochaTest:
      test:
        options:
          reporter: 'dot'
        src: ['test/**/*.js']

    shell:
      jison_generate:
        command: "jison src/grammar/tls-grammar.jison -o grammar/tls-grammar.js"
        options:
          stdout:true
          stderr:true
      generate:
        command: "node main/generator.js"
        options:
          stdout:true
          stderr:true
    
    copy:
      txt:
        files: [
          { expand: true, cwd:'src/',src: ['**/*.txt'], dest: './' }
        ] 

    t2c:
      options: 
        output_language:'coffee'  
      build:
        expand: true,
        cwd: './src',
        src: ['**/*.t2c'],
        dest: './src',
        ext: '.coffee'
        extDot : 'last'    


  grunt.loadNpmTasks('grunt-contrib-coffee')
  grunt.loadNpmTasks('grunt-mocha-test')
  grunt.loadNpmTasks('grunt-shell')
  grunt.loadNpmTasks('grunt-contrib-copy')
  grunt.loadNpmTasks('grunt-t2c')

  grunt.registerTask('default', ['shell:jison_generate','t2c','coffee','copy:txt','mochaTest'])
  
  grunt.registerTask('generate', ['coffee','shell:generate'])





