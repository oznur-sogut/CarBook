using CarBook.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.DataAccessLayer.Abstract
{
	//GenericDal interface içinde bulunan tüm işlemleri brand sınıfına dahil etme işlemi
	public interface IBrandDal:IGenericDal<Brand>
	{
	}
}
