using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Parcial2.Models;

namespace Parcial2.Repositorios
{
    public interface IDirectoresRepository
{
    public List<Director> GetAll();
    public Director GetById(int id);
    public void Create(Director director);
    public void Remove(int id);
    public void Update(Director director);
}
}