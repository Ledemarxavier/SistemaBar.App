
# 🍻 Sistema de Bar 2025

> **Sistema de Gerenciamento de Bares** — completo, organizado e com design orientado a objetos.

Bem-vindo ao sistema **Controle de Bar 2025**! Uma aplicação em C# voltada para o gerenciamento de mesas, garçons, produtos e pedidos em bares. 

---

## 🚀 Funcionalidades

### 🪑 Mesas
- 📥 Cadastro de novas mesas
- 🔄 Edição e visualização
- ❌ Exclusão apenas se **não houver pedidos vinculados**
- ✅ Status: **Livre / Ocupada**
- 🔒 Número exclusivo para cada mesa

### 🧑‍🍳 Garçons
- 📥 Cadastro com nome e CPF
- 🔍 Validação automática de CPF
- 🚫 Sem CPFs duplicados
- ❌ Sem exclusão se houver contas associadas

### 🍔 Produtos
- 📥 Cadastro de produtos com nome e valor
- 💡 Validação de nomes únicos
- 💵 Preço com até 2 casas decimais
- ❌ Exclusão bloqueada se o produto estiver em pedidos

### 💳 Contas
- 🆕 Abrir conta com **cliente, mesa e garçom**
- ➕ Adicionar pedidos (produto + quantidade)
- ➖ Remover pedidos
- 🔐 Contas com status: **Aberta / Fechada**
- 📊 Faturamento diário calculado automaticamente
- 🔍 Visualização de:
  - Contas em aberto
  - Contas fechadas
  - Faturamento total do dia

---

## 🛠️ Tecnologias 
[![My Skills](https://skillicons.dev/icons?i=visualstudio,dotnet,cs,git,github,)](https://skillicons.dev)

---

## Requisitos

- .NET SDK (recomendado .NET 8.0 ou superior) para compilação e execução do projeto.
---

## Como executar

 #### Clone o Repositório
 ```
 git clone https://github.com/LedemarXavier/SistemaBar.App.git
 ```
 
 #### Navegue até a pasta raiz da solução
 ```
 cd SistemaBar.App
 ```
 
 #### Restaure as dependências
 ```
 dotnet restore
 ```
 
 #### Navegue até a pasta do projeto
 ```
 cd SistemaBar
 ```
 
 #### Execute o projeto
 ```
 dotnet run
 ````
 ----

## 👨‍🎓 Projeto Acadêmico

Desenvolvido por **Ledemar Xavier** — 2025  
Disciplina: **Programação Orientada a Objetos / Projeto Final**

---


