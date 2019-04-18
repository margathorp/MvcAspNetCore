const superb = require('superb')

module.exports = {
  prompts() {
    return [
      {
        name: 'Projeto',
        message: 'Nome do Projeto',
        default: ""
      },
      {
        name: 'Controller',
        message: 'Nome da Area/Controller',
        default: ""
      },
      {
        name: 'ObjContext',
        message: 'Objeto do contexto',
        default:"",
        store: true
      },
      {
        name: 'Fields',
        message: 'Campo,Tipo(text/date/bool/list),Mascara,Hidden(h/s)',
        default: "",
        store: true
      },
      {
        name: 'Includes',
        message: 'Informe os includes',
        default: "",
        store: true
      }

    ]
  },
  actions: [
    {
      type: 'move',
      files: 'Controller.cs'
    },
    {
      type: 'add',
      files: 'DTO.cs'
    },
    {
      type: 'add',
      files: 'Repository.cs'
    },
    {
      type: 'add',
      files: 'Create.cshtml'
    },
    {
      type: 'add',
      files: 'Edit.cshtml'
    },
    {
      type: 'add',
      files: 'Details.cshtml'
    },
    {
      type: 'add',
      files: 'Delete.cshtml'
    },
    {
      type: 'add',
      files: 'Index.cshtml' 
    }
  ],
  async completed() {
    this.gitInit()
    await this.npmInstall()
    this.showProjectTips()
  }
}
