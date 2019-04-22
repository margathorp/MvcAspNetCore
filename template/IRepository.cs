using System.Collections.Generic;
using <%=Projeto%>.Models.Context;
using <%=Projeto%>.Models.ViewModel;

namespace <%=Projeto%>.Models.Repository
{
    public interface I<%=ObjContext%>Repository : IRepository< <%=ObjContext%> >
    {
        IEnumerable< <%=ObjContext%>ViewModel > GetIndexValues(DataTableAjaxPostModel param, out int qtdRegistros, out int qtdRegistrosFiltro);
    }
}