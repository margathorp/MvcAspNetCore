const superb = require('superb')

module.exports = {
  prompts() {
    return [
      {
        name: 'Projeto',
        message: 'Nome do Projeto',
        default: "",
        store: true
      },
      {
        name: 'Area',
        message: 'Nome da Area',
        default: "",
        store: true
      },
      {
        name: 'Controller',
        message: 'Nome do Controller',
        default: "",
        store: true
      },
      {
        name: 'ObjContext',
        message: 'Objeto do contexto',
        default:"",
        store: true
      },
      {
        name: 'PrimaryKeyModel',
        message: 'Chave Primária Model',
        default:"",
        store: true
      },
      {
        name: 'PrimaryKeyDb',
        message: 'Chave Primária Db',
        default:"",
        store: true
      },
      {
        name: 'Fields',
        message: 'Campo,Tipo(text/date/bool/list),Mascara,Hidden(h/s),NomeDatabase,DescTela,required(*),RequiredText',
        default: "",
        store: true
      },
      {
        name: 'EnderecoLista',
        message: 'Informe Endereço da Listagem',
        default: "",
        store: true
      }

    ]
  },
  actions: [
    {
      type: 'add',
      files: 'Controller.cs'
    },
    {
      type: 'add',
      files: 'ViewModel.cs'
    },
    {
      type: 'add',
      files: 'Repository.cs'
    },
    {
      type: 'add',
      files: 'IRepository.cs'
    },
    {
      type: 'add',
      files: 'Metadata.cs'
    },
    {
      type: 'add',
      files: 'Index.cshtml' 
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
    }
    
    
  ],
  async completed() {
    this.gitInit()
    await this.npmInstall()
    this.showProjectTips()
  }
}
