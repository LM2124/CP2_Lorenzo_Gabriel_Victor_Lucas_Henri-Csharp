# Sistema de Gerenciamento de Consultas Médicas

Este é um sistema de linha de comando desenvolvido em C# (.NET 8), cujo objetivo é gerenciar pacientes, médicos e consultas em uma clínica médica. Ele permite:

- Cadastro de pacientes e médicos
- Agendamento, alteração e cancelamento de consultas
- Listagem de consultas e geração de relatórios diários

## 🛠 Versão utilizada
- **.NET:** 8.0

## 📦 Estrutura de Arquivos


## ▶️ Como Executar no Visual Studio

1. **Abra o Visual Studio.**
2. Vá em **"Arquivo" > "Novo" > "Projeto"**.
3. Escolha o template **"Aplicativo de Console (.NET Core ou .NET 8)"**.
4. Dê um nome ao projeto e clique em **"Criar"**.
5. Substitua os arquivos gerados (`Program.cs`) pelos arquivos fornecidos:
   - `Program.cs`
   - `Paciente.cs`
   - `Medico.cs`
   - `Consulta.cs`
6. **Certifique-se que o namespace seja o mesmo em todos os arquivos (`CP2`)**.
7. Pressione **F5** ou clique em **"Iniciar"** para executar o sistema.

## 👥 Integrantes do Grupo
- RM 99389 - Victor Flávio Demarchi Viana
- RM 551117 - Lorenzo Gomes Andreata
- RM 550695 - Gabriel Ferla
- RM 97158 - Lucas Moreno Matheus
- RM 98347 - Henri de Oliveira Lopes

## 💡 Funcionalidades em Destaque

- Interface de texto simples com menus navegáveis
- Cadastro e gerenciamento de pacientes, médicos e consultas
- Geração de relatório diário com cálculo de intervalos entre consultas
- Projeto orientado a objetos com uso de `Guid`, `DateOnly`, `TimeOnly` e listas genéricas
