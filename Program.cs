using System;

namespace Screening_covid
{
    class Program
    {
        static void Main(string[] args)
        {
            int age,numericName; // Patient's age && (check if the user answered with number).
            bool fever, cough, respiratoryProblem; //Initial symptoms, to check if screening is proceeding.
            bool shortnessOfBreathe, increasedRespiratoryRate, chestPain, feelingFaint;//alarm symptoms.
            bool alarmSignals, riskFactor;//checking the severity of the disease.
            bool hypertension, diabetes, otherChronicDiseases;//chronic illnesses for minors.
            bool CoronaryDisease, chronicDisease;//chronic illnesses for adults.
            bool situation; //Patient's situation.
            

            Console.Clear();
            Console.WriteLine("---Triagem para Covid-19---\n");
            Console.WriteLine("\nAdaptado de http://www.slmandic.edu.br/tudo-sobre-coronavirus/\n");
            Console.ForegroundColor= ConsoleColor.DarkRed;
            Console.WriteLine("RESULTADO ESTRITAMENTE EDUCACIONAL, PROCURE AJUDA ESPECIALIZADA.\n");
            Console.ResetColor();

            Console.Write("Por favor, para proceguirmos digite seu primeiro nome: ");
            string username= Console.ReadLine();
            bool nameDescribed= Int32.TryParse( username,out numericName); //True or false

                if (nameDescribed)
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("\nNOME INVÁLIDO!");
                    Console.ResetColor();
                    Environment.Exit(-1);
                }

            Console.Write("\n\nQual a idade do paciente?..: ");
            bool numericalAge= Int32.TryParse(Console.ReadLine(), out age );
            
                if (!numericalAge || age< 0 || age> 130)
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("\nIDADE INVÁLIDA!");
                    Console.ResetColor();
                    Environment.Exit(-1);
                }

            Console.Clear();
            Console.WriteLine($"\nOlá {username!}\n");
            Console.WriteLine("Nesse processo de triagem serão realizadas algumas perguntas, por favor responda corretamente.");

            
            Console.WriteLine("\nResponda [S] para SIM ou outro caracter para [NÃO].");
            Console.Write("O paciente entá com febre?..: ");
            fever= Console.ReadLine().ToUpper()=="S";
            
            Console.Write("O paciente entá com tosse?..: ");
            cough= Console.ReadLine().ToUpper()=="S";

            Console.Write("O paciente está com qualquer outro problema respiratório?..: ");
            respiratoryProblem= Console.ReadLine().ToUpper()=="S";

                if (!fever && !cough && !respiratoryProblem)
                {
                    Console.ForegroundColor= ConsoleColor.Green;
                    Console.Write("\n*O paciente em questão não necessita de nenhuma recomendação especifica. #FIQUEEMCASA"); 
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor= ConsoleColor.Yellow;
                    Console.WriteLine("\n\nSINAIS DE ALARME!");
                    Console.ResetColor();

                    Console.Write("\nO paciente entá com falta de ar?..: ");
                    shortnessOfBreathe= Console.ReadLine().ToUpper()=="S";

                    Console.Write("O paciente entá com aumento da frequência respiratória?..: ");
                    increasedRespiratoryRate= Console.ReadLine().ToUpper()=="S";

                    Console.Write("O paciente entá com dor trorácica?..: ");
                    chestPain= Console.ReadLine().ToUpper()=="S";

                    Console.Write("O paciente entá com sensação de desmaio?..: ");
                    feelingFaint= Console.ReadLine().ToUpper()=="S";

                    alarmSignals= shortnessOfBreathe 
                        || increasedRespiratoryRate 
                        || chestPain 
                        || feelingFaint;

                    if (age < 18)
                    {
                        Console.Clear();
                        Console.ForegroundColor= ConsoleColor.DarkYellow;
                        Console.WriteLine("\nFATORES DE RISCO PARA MENORES!");
                        Console.ResetColor();

                        Console.Write("\n\nO paciente tem hipertensão areterial sistemica ?..: ");
                        hypertension= Console.ReadLine().ToUpper()=="S";

                        Console.Write("O paciente tem diabetes melite ?..: ");
                        diabetes= Console.ReadLine().ToUpper()=="S";

                        Console.Write("O paciente possui alguma outra doença cronica?..: ");
                        otherChronicDiseases= Console.ReadLine().ToUpper()=="S";

                        riskFactor= hypertension || diabetes || otherChronicDiseases;
                    }
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor= ConsoleColor.DarkYellow;
                        Console.WriteLine("\nFATORES DE RISCO PARA MAIORES!");
                        Console.ResetColor();

                        Console.Write("\n\nO paciente possui alguma doença coronária prévia?..: ");
                        CoronaryDisease= Console.ReadLine().ToUpper()=="S";

                        Console.Write("O paciente possui alguma doença cronica desconpensada?..: ");
                        chronicDisease= Console.ReadLine().ToUpper()=="S";

                        riskFactor= (age > 65)
                            ||CoronaryDisease 
                            ||chronicDisease
                            ||increasedRespiratoryRate;
                    }
                    
                    
                    if (alarmSignals ||riskFactor)
                    {
                        Console.Clear();
                        Console.ForegroundColor= ConsoleColor.DarkCyan;
                        Console.WriteLine("\nSITUAÇÃO DO PACIENTE");
                        Console.ResetColor();
                        Console.Write("\n\nO paciente se encontra em uma situação grave?..:");
                        situation= Console.ReadLine().ToUpper()=="S";

                        if(situation)
                        {
                            Console.Clear();
                            Console.ForegroundColor= ConsoleColor.DarkRed;
                            Console.WriteLine("\n\nENCAMINHAR AMBULÂNCIA PARA O LOCAL.");
                            Console.ResetColor(); 
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Clear();
                            Console.ForegroundColor= ConsoleColor.DarkMagenta;
                            Console.WriteLine("\n\nENCAMINHAR PARA  O SISTEMA DE SAÚDE.");
                            Console.ResetColor();  
                            Console.ReadKey(); 
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor= ConsoleColor.Yellow;
                        Console.WriteLine("\n\nÉ RECOMENDADO ISOLAMENTO SOCIAL! #FIQUEEMCASA.");
                        Console.ResetColor();
                    }
                }
            Console.ResetColor();
            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine("\nObrigada por utilizar o nosso programa! ");
            Console.ResetColor();
            Console.ReadKey();
            
        }
    }
}
