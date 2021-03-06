﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace DataLayer
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
    using System.Data.Entity;

	public class ScoresRepository
	{
        private DBScoresContainer _context;

        public ScoresRepository(DBScoresContainer context)
        {
            _context = context;
        }

		public virtual List<Scores> List
		{
            get
            {
                return _context.ScoresSet.OrderByDescending(x => x.Points).ToList();
            }
		}

		public virtual bool AddScores(string name, int points)
		{
            try
            {
                Scores scores = new Scores() { Name = name, Points = points };
                _context.ScoresSet.Add(scores);
                return _context.SaveChanges() > 0;

            }
            catch (Exception)
            {
                return false;
            }
        }

	}
}

