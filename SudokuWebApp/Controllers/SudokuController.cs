using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SudokuWebApp.Models;

namespace SudokuWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SudokuController : ControllerBase
    {
        // POST api/sudoku
        [HttpPost]
        public Sudoku SolveSudoku([FromBody] Sudoku unsolved)
        {
            var board = unsolved.board;

            var solution = SudokuWebApp.Program.SudokuSolver(board);

            var solved = new Sudoku(solution);

            return solved;
        }
    }
}