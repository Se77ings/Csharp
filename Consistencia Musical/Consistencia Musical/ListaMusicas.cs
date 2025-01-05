using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace Consistencia_Musical
{
    internal static class ListaMusicas
    {
        private static string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../app_data/musicas.json");

        public static void Listar()
        {
            try
            {
                string jsonString = File.ReadAllText(filePath);

                List<Musica> musicas = JsonSerializer.Deserialize<List<Musica>>(jsonString);

                for (int i = 0; i < musicas.Count; i++)
                {
                    Console.WriteLine($"Música {i}:");
                    musicas[i].exibeMusica();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao listar músicas: {ex.Message}");
            }
        }

        public static int getLastId()
        {
            List<Musica> listaMusical = JsonSerializer.Deserialize<List<Musica>>(File.ReadAllText(filePath));
            Console.WriteLine("Lista de músicas carregada com sucesso.");
            var ultimoID = listaMusical.Last().id;
            return ultimoID;
        }

        public static void GravaArquivo(List<Musica> musicas)
        {
            try
            {
                // Formatar todas as músicas antes de gravar
                foreach (var musica in musicas)
                {
                    FormatarMusica(musica);
                }

                // Serializar a lista atualizada em JSON
                string jsonString = JsonSerializer.Serialize(musicas);

                // Ler o conteúdo atual do arquivo se existir
                string existingJson = "";
                if (File.Exists(filePath))
                {
                    existingJson = File.ReadAllText(filePath);
                }

                // Verificar se já existe conteúdo no arquivo
                if (!string.IsNullOrEmpty(existingJson))
                {
                    // Remover o último caractere (']') do JSON existente
                    existingJson = existingJson.Substring(0, existingJson.Length - 1);

                    // Adicionar uma vírgula para separar os objetos JSON
                    existingJson += ",";

                    // Adicionar o novo JSON à string existente
                    existingJson += jsonString.Substring(1); // Ignora o primeiro caractere '{' do novo JSON
                }
                else
                {
                    // Se o arquivo está vazio, escrever apenas o JSON
                    existingJson = jsonString;
                }

                // Fechar a lista JSON com ']'
                existingJson += "]";

                // Gravar o JSON atualizado no arquivo
                File.WriteAllText(filePath, existingJson);

                Console.WriteLine("Lista de músicas gravada com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao gravar arquivo: {ex.Message}");
            }
        }

        private static void FormatarMusica(Musica musica)
        {
            // Formatar o nome da música e o nome do artista com capitalização correta
            musica.nome = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(musica.nome.ToLower());
            musica.artista = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(musica.artista.ToLower());

            // Outros campos relevantes podem ser formatados aqui se necessário
        }
    }
}
