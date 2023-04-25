using Models;
using MyData;

namespace Controllers{

    public class SaldoController{

        public static void Create(Saldo saldo){
            using (var context = new Context()){
            context.Saldos.Add(saldo);
            context.SaveChanges();
            }
        }

        public static List<Saldo> Read(){
            using (var context = new Context()){
            return context.Saldos.ToList();
            }
        }

        public static Saldo ReadById(int idSaldo){
            using (var context = new Context()){
                var saldo = context.Saldos.Find(idSaldo);
                if(saldo == null){
                    throw new ArgumentException("Saldo não encontrado");
                }
                else{
                    return saldo;
                }
            }
        }

        public static Saldo Update(Saldo saldo){
            using (var context = new Context()){
                context.Saldos.Update(saldo);
                context.SaveChanges();
            }
        }

        public static void Delete(Saldo saldo){
            using (var context = new Context()){
                context.Saldos.Remove(saldo);
                context.SaveChanges();
            }
        }
    }
}