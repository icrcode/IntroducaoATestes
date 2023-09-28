using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste
{
    internal static class ArgExExtension
    {
        public static void ComMensagem(
            //veja o poder do ponteiro
            this ArgumentException excecao,
            string mensagem
            ) 
        {
        
            if ( excecao.Message == mensagem ) 
            { 
                Assert.True( true );
            }
            else
            {
                Assert.False( true );
            }
        
        }
    }
}
