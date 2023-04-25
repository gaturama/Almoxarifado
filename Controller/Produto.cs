using Models;
using MyData;

namespace Controllers{

    public class ProdutoController{

        public static void Create(Produto produto){
            using (var context = new Context()){
                context.Produtos.Add(produto);
                context.SaveChanges();
            }
        }

        public static List<Produto> Read(){
            using (var context = new Context()){
                return context.Produtos.ToList();
            }
        }

        public static Produto ReadById(int idProduto){
            using (var context = new Context()){
                var produto = context.Produtos.Find(idProduto);
                if (produto == null){
                    throw new ArgumentException("Produto não encontrado");
                }
                else{
                    return produto;
                }
            }
        }

        public static void Update(Produto produto){
            using (var context = new Context()){
                context.Produtos.Update(produto);
                context.SaveChanges();
            }
        }

        public static void Delete(Produto produto){
            using (var context = new Context()){
                context.Produtos.Remove(produto);
                context.SaveChanges();
            }
        }
    }
}