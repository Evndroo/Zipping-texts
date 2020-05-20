using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zipando_textos
{
    class Program
    {
        static void Main(string[] args)
        {
            var comprimido = "";
            var dicionario = "";

            Console.WriteLine("Insira um texto e saiba como ele ficaria zipado: ");
            var txt = Console.ReadLine();

            char[] txtArr;
            Console.WriteLine("");

            txtArr = txt.ToCharArray();

            for (int i = 0; i <= (txtArr.Length - 1); i++) {
                var size = 1;

                if (dicionario.IndexOf(txtArr[i]) > 0)
                {
                    if ((i - dicionario.IndexOf(txtArr[i]) - 1) >= 10) {
                        comprimido += dicionario.Substring(dicionario.Length - 9, 9).IndexOf(txtArr[i]) + "1 ";
                        dicionario += txtArr[i];
                    }
                    else
                    {
                        //   primeira condição previne que dê excessão na segunda condição no ultimo caractere 
                        while ((i < txtArr.Length - 1) && (dicionario.IndexOf(txtArr[i + 1]) == (dicionario.IndexOf(txtArr[i]) + 1)))
                        {
                            size++;
                            i++;
                        }
                        comprimido += i - dicionario.IndexOf(txtArr[i]) + size.ToString() + " ";
                        dicionario += txtArr[i];
                    }
                } else if (dicionario.IndexOf(txtArr[i]) == dicionario.IndexOf(txtArr[0])) {
                    //igual o primeiro caractere
                    //motivo: o c# tanto quando encontra com o index of uma incidência no primeiro caractere quanto quando não encontra incidência retorna 0. 
                    comprimido += i.ToString();
                    while ( (i<txtArr.Length-1) &&(dicionario.IndexOf(txtArr[i + 1]) == (dicionario.IndexOf(txtArr[i]) + 1)))
                    {
                        size++;
                        i++;
                    }
                    comprimido += size.ToString() + " ";
                    dicionario += txtArr[i];
                }
                else { //Primeira incidência de um caractere
                    comprimido += "0" + txtArr[i] + " ";
                    dicionario += txtArr[i];
                }
                
            }
            Console.WriteLine(comprimido);
            Console.WriteLine("");
            Console.WriteLine("Aperte qualquer tecla para sair");
            Console.ReadKey(); //Read key para permitir que o usuário leia o resultado.
        }
    }
}
