using Models;
using MyData;

namespace Controllers{
    public class AlmoxarifadoController{
        public void Create(AlmoxarifadoController almoxarifado){
            using(var context = new Context()){
                context.Almoxarifados.Add(almoxarifado);
                context.SaveChanges();
            }
        }

        public static List<AlmoxarifadoController> Read(){
            using (var context = new Context()){
                return context.Almoxarifados.ToList();
            }
        }

        public static AlmoxarifadoController ReadById(int idAlmoxarifado){
            using (var context = new Context()){
                var almoxarifado = context.Almoxarifados.Find(idAlmoxarifado);
                if (almoxarifado == null)
                {
                    throw new ArgumentException("Almoxarifado não encontrado");
                }
                else
                {
                    return almoxarifado;
                }
            }
        }

        public static void Update(AlmoxarifadoController almoxarifado){
            using (var context = new Context()){
                context.Almoxarifados.Update(almoxarifado);
                context.SaveChanges();
            }
        }

        public static void Delete(AlmoxarifadoController almoxarifado){
            using (var context = new Context()){
                context.Almoxarifados.Remove(almoxarifado);
                context.SaveChanges();
            }
        }
    }
}