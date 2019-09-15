using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SudokuWebApp.Models
{
    public class Sudoku
    {
        public string board;
        public Sudoku(string board)
        {
            this.board = board;
        }

        internal IActionResult ToHttpResponse()
        {
            throw new NotImplementedException();
        }
    }
}
