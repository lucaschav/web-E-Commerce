using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VPNET.Data.Model;

namespace data_model.Manager
{
    public class Categorias_Manager
    {
        private Model_Context db = new Model_Context();

        public List<Categorias> getCategorias()
        {
            var result = db.Categorias.ToList();

            return result;
        }
    }
}
