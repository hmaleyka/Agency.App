﻿using Agency.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Core.Entities
{
	public  class Portfolio : BaseEntity
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public string ImgUrl { get; set; }
	}
}
