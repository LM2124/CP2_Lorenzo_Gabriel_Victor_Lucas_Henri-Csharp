# Sistema de Gerenciamento de Consultas Médicas

Este é um sistema de linha de comando desenvolvido em C# (.NET 8), cujo objetivo é gerenciar pacientes, médicos e consultas em uma clínica médica. Ele permite:

- Cadastro de pacientes e médicos
- Agendamento, alteração e cancelamento de consultas
- Listagem de consultas e geração de relatórios diários

## 🛠 Versões utilizadas
- **Visual Studio:** 2022
- **.NET:** 8.0

## ▶️ Como Executar:

1. Abra o Visual Studio 2022.
2. Clique na opção **Clone a Repository**.
3. No campo **Repository Location**, digite a seguinte URL: `https://github.com/LM2124/CP2_Lorenzo_Gabriel_Victor_Lucas_Henri-Csharp`
4. Clique no botão **Clone** e espere o projeto abrir.
5. Pressione **F5** ou clique em **Start** para executar o sistema.

## 👥 Integrantes do Grupo
- RM 99389 - Victor Flávio Demarchi Viana
- RM 551117 - Lorenzo Gomes Andreata
- RM 550695 - Gabriel Ferla
- RM 97158 - Lucas Moreno Matheus
- RM 98347 - Henri de Oliveira Lopes

## 💡 Funcionalidades em Destaque

- `CadastrarPaciente()` Responsável por adicionar um novo paciente a lista de pacientes, ao fornecer o nome, CPF e data de nascimento
- `CadastrarMedico()` Responsável por adicionar um novo médico a lista de médicos, ao fornecer o nome, CRM e especialidade.
- `SelecionarEmLista()` Coleta uma das listas (pacientes ou médicos) e cria um prompt para seleção dos mesmos
- `AgendarConsulta()` Através do **SelecionarLista()**, coleta o médico e o paciente, juntamente com a data e hora da consulta, e marca a consulta do paciente selecionado na lista do médico.
- `ListarConsultas()` Verifica todas as consultas presentes nos médicos registrados, retornando data, hora, médico responsável, paciente e hora de registro da consulta
- `AlterarConsultas()` Através do **SelecionarLista()**, coleta as consultas disponíveis e permite alterar a data ou hora, cancelar a consulta, ou cancelar a operação e voltar ao menu
- `GerarRelatorio()` Indica se há consultas marcadas para o dia de hoje, e caso hajam, listam nome do paciente, nome do médico e horário da consulta, e o intervalo de tempo médio entre as consultas de hoje. 
