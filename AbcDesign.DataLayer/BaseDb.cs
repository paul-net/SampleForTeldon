using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcDesign.DataLayer;

public abstract class BaseDb
{
	protected readonly string _dbstr;

	protected BaseDb(string dbstr)
	{
		_dbstr = dbstr;
	}

	/* add others common methods */
}
