<%  var fields = Fields.split("|");
    var nome = "";
    var tipo = "";
    var mask = "";
    var hidden = ""; 
    var databasename = "";%>
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text.RegularExpressions;
using <%=Projeto%>.Models.Context;
using <%=Projeto%>.Models.ViewModel;

namespace <%=Projeto%>.Models.Repository
{
    public class <%=ObjContext%>Repository : Repository< <%=ObjContext%> >, I<%=ObjContext%>Repository
    {
        public <%=ObjContext%>Repository(AppDbContext context) : base(context)
        {
        }
        public IEnumerable< <%=ObjContext%>ViewModel > GetIndexValues(DataTableAjaxPostModel param, out int qtdRegistros, out int qtdRegistrosFiltro)
        {
            string condition = "";
            int i = 1;
            
            foreach (var condicao in param.columns.Where(c => c.search.value != null))
            {
                Regex rgx = new Regex("[^a-zA-Z0-9 -]");
                condicao.search.value = rgx.Replace(condicao.search.value, "").ToLower();
                if (i == param.columns.Where(c => c.search.value != null).Count())
                {
                    condition += string.Format("{0}.ToString().ToLower().Contains(\"{1}\") ", condicao.data, condicao.search.value);
                }
                else
                {
                    condition += string.Format("{0}.ToString().ToLower().Contains(\"{1}\") && ", condicao.data, condicao.search.value);
                }
                i++;
            }
            string order = "<%=PrimaryKeyModel%>" ;
            if (param.order.Count() > 0)
            {
                var ord = param.order.FirstOrDefault();
                var column = param.columns.ToArray()[ord.column];
                order = column.data + " " + ord.dir;
            }
            qtdRegistros = _dbSet.Count();
            var query = _dbSet
                        .Select(q => new <%=ObjContext%>ViewModel()                        
                        {Actions = q.<%=PrimaryKeyDb%>,
                            <% for(var i = 0; i < fields.length; i++){ nome = fields[i].split(",")[0]; tipo = fields[i].split(",")[1]; mask = fields[i].split(",")[2];hidden = fields[i].split(",")[3];databasename = fields[i].split(",")[4];nometela = fields[i].split(",")[5];%>
                            <%=nome%> = q.<%=databasename%>, <%}%>
                        }).AsQueryable();
            if (condition != "")
            {
                query = query.Where(condition);
            }
            qtdRegistrosFiltro = query.Count();           
            return query.OrderBy(order).Skip(param.start).Take(param.length).ToList();


        }
    }
}