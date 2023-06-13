using NewProj.Models;
using System.Data.SqlClient;

namespace NewProj.Interface
{
    public interface IName
    {
        public List<People> GetProductList();
        public void EditUpdateProduct(People people);
        public void DeleteProductByID(int Id);

        public void GetUserByID(int ProductId);


    }
}

