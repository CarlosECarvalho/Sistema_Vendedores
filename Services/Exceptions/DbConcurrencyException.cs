﻿namespace SalesWebMVC.Services.Exceptions
{
	public class DbConcurrencyException : ApplicationException
	{
		public DbConcurrencyException(string messege) : base(messege) { }
	}
}
