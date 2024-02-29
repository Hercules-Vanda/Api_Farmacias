using Api_farmacias.Model;
using Api_Farmacias.Model;
using Api_Farmancias.DAL.Database;
using Api_Farmancias.Repositorio.InterFace;
using Microsoft.EntityFrameworkCore;


namespace Api_Farmancias.Repositorio
{
    public class FarmaciaRepository : IFarmaciaRepisitory
    {
        private readonly Appdbcontext _conexao;
        public FarmaciaRepository(Appdbcontext conexaoDB)
        {
            _conexao = conexaoDB;
        }
        public async Task<List<Farmacia>> Farmancias()
        {
            return await _conexao.farmancias.ToListAsync();
        }
        public async Task<Farmacia> BuscarFarmacia(int id)
        {
            return await _conexao.farmancias.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Farmacia> AdicionarFarmacia(Farmacia farmacia)
        {
            await _conexao.farmancias.AddAsync(farmacia);
            await _conexao.SaveChangesAsync();
            return farmacia;
        }
        public async Task<Farmacia> Atualizar(Farmacia farmacia, int id)
        {
            Farmacia farmaciaid = await BuscarFarmacia(id);
            if(farmaciaid == null)
            {
                throw new Exception($"Farmacia para o ID:{id} nao encontrado.");
            }

            farmaciaid.Nome = farmacia.Nome;
            farmaciaid.NIF = farmacia.NIF;

            _conexao.farmancias.Update(farmaciaid);
            await _conexao.SaveChangesAsync();

            return farmaciaid;
        }

        public async Task<bool> Apagar(int id)
        {
            Farmacia farmaciaid = await BuscarFarmacia(id);
            if(farmaciaid == null)
            {
                throw new Exception($"Farmacia para o ID:{id} nao encontrado.");
            }

            _conexao.farmancias.Remove(farmaciaid);
            await _conexao.SaveChangesAsync();
            return true;
        }

        public Task<bool> SaveAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}