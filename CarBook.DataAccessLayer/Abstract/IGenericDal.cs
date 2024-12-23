using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.DataAccessLayer.Abstract
{
	//T değeri Entity Sınıflarını tutan değer. Her bir Entity sınıfı için ayrı arı entity komutlarını kullanmadan kod tekrarını önleyecek şekilde eklemiş olduk. Generic yapı kod tekrarını önler
	public interface IGenericDal<T> where T : class
	{
		void Insert(T entity);
		void Delete(T entity);
		void Update(T entity);
		List <T> GetListAll();
		T GetByID(int id);
	}
}
