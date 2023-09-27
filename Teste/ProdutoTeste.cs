using ExpectedObjects;
using System.Runtime.CompilerServices;

namespace Teste
{
    public class ProdutoTeste
    {
        /*
        Eu, como almoxarife, preciso cadastrar produtos para que sejam
        consumidos pelos funcinários da empresa

        Critérios de aceite?
        1 - Um novo produto deve ter obrigatoriamente um código único, nome,saldo 0, custo 0 e unidade de medida
        2 - As unidades de medida são PC, KG, MT, GR, LT, CX
        3 - Um produto PODE  ter uma descrição
        4 - Um produto PODE ter um código de barras EAN
        */

        //propriedade
        private int _codigo;
        private string _nome;
        private double _saldo;
        private double _custo;
        private string _medida;

        //método construtor
        public ProdutoTeste()
        {
            this._codigo = 1;
            this._nome = "Caneco";
            this._saldo = 0;
            this._custo = 0;
            this._medida = "PC";
        }

        [Fact]
        public void CriarObjeto()
        {

            // Arrange - prepara as variáveis
            /*
            int codigo = 1;
            string nome = "Caneca";
            double saldo = 0;
            double custo = 0;
            string medida = "PC";
            */


            // Objeto - Anonimo

            /*
             Primeiro Metodo

            var obj = new { 
                codigo = 1,
                nome = "Caneca",
                saldo = (double)0,
                custo = (double)0,
                medida = "PC"
            };

            // Act - executa uma operação
            //Produto produto = new Produto(codigo, nome, saldo, custo, medida);
            Produto produto = new Produto(obj.codigo, obj.nome, obj.saldo, obj.custo, obj.medida);

            // Assert - verifica o resultado da operação
            Assert.Equal(obj.codigo, produto.Codigo);
            Assert.Equal(obj.nome, produto.Nome);
            Assert.Equal(obj.saldo, produto.Saldo);
            Assert.Equal(obj.custo, produto.Custo);
            Assert.Equal(obj.medida, produto.Medida);

             */

            // Terceira Forma
            /*
                Produto produto = new Produto(this._codigo, this._nome, this._saldo, this._custo, this._medida);

                Assert.Equal(this._codigo, produto.Codigo);
                Assert.Equal(this._nome, produto.Nome);
                Assert.Equal(this._saldo, produto.Saldo);
                Assert.Equal(this._custo, produto.Custo);
                Assert.Equal(this._medida, produto.Medida);
            */

            var obj = new
            {
                Codigo = this._codigo,
                Nome = this._nome,
                Saldo = this._saldo,
                Custo = this._custo,
                Medida = this._medida
            };

            Produto produto = new Produto(obj.Codigo, obj.Nome, obj.Saldo, obj.Custo, obj.Medida);

            obj.ToExpectedObject().ShouldMatch(produto);

        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ProdutoNomeInválido(string nomeInvalido)
        {
            Assert.Throws<ArgumentException>( ()=> new Produto(this._codigo, nomeInvalido, this._saldo, this._custo, this._medida));
        }

    }

    internal class Produto
    {
        private int codigo;
        private string nome;
        private double saldo;
        private double custo;
        private string medida;

        public Produto(int codigo, string nome, double saldo, double custo, string medida)
        {

            if(string.IsNullOrEmpty(nome)) //(nameof == "" || nome = null)
            {
                throw new ArgumentException();
            }

            this.Codigo = codigo;
            this.Nome = nome;
            this.Saldo = saldo;
            this.Custo = custo;
            this.Medida = medida;
        }

        public int Codigo { get => codigo; private set => codigo = value; }
        public string Nome { get => nome; private set => nome = value; }
        public double Saldo { get => saldo; private set => saldo = value; }
        public double Custo { get => custo; private set => custo = value; }
        public string Medida { get => medida; private set => medida = value; }
    }
}