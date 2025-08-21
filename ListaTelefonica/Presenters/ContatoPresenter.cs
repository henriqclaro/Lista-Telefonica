using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListaTelefonica.Models;

namespace ListaTelefonica.Presenters
{
    public class ContatoPresenter
    {
        private Contexto db;
        public ContatoPresenter()
        {
            db = new Contexto();
            db.Database.EnsureCreated();
        }

        public bool AdicionarContato(Contato novo)
        {
            db.Contatos.Add(novo);
            return  db.SaveChanges() > 0;
        }

        public List<Contato> BuscarContatos(string busca = "") 
        {
            busca = busca.ToLower();
            if(busca == "")
            {
                return db.Contatos.ToList();
            }
            return
                db.Contatos.Where(c => c.Nome.ToLower().Contains(busca) || c.Telefone.Contains(busca)).ToList();
        }

        public Contato SelecionarContato(int id)
        {
            return db.Contatos.Find(id);
        }

        public bool EditarContato(Contato contato)
        {
            db.Contatos.Update(contato);
            return db.SaveChanges() > 0;
        }

        public bool RemoverContato(Contato contato)
        {
            db.Contatos.Remove (contato);
            return db.SaveChanges() > 0;
        }
    }

}
