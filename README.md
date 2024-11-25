# Blog

Este é um sistema básico de blog desenvolvido com os princípios de orientação a objetos e os conceitos de design SOLID. O projeto inclui funcionalidades de autenticação e gerenciamento de postagens.

## Descrição

O Blog  permite que os usuários visualizem, criem, editem e excluam postagens. O projeto é focado em:
- Princípios de orientação a objetos.
- Boas práticas de design (SOLID).
- Integração com o Entity Framework para manipulação de dados.

## Funcionalidades

### Usuários
- **Registro e Login**: Os usuários podem se registrar e autenticar-se no sistema.

### Gerenciamento de Postagens
- **Criar, Editar e Excluir Postagens**: Usuários autenticados podem gerenciar suas próprias postagens.
- **Visualizar Postagens**: Visitantes não autenticados podem visualizar postagens existentes.

## Requisitos Técnicos
1. **Arquitetura Monolítica**:
   - As responsabilidades estão organizadas em autenticação e gerenciamento de postagens.
2. **Autenticação e autorização**:
   - Uso de tokens de validação através de Json Web Tokens (JWT).
3. **Princípios SOLID**:
   - Aplicação especial do Princípio da Responsabilidade Única (SRP) e da Inversão de Dependência (DIP).
4. **Entity Framework**:
   - Utilizado para persistência e manipulação de dados de usuários e postagens.

## Camada da aplicação
### Estrutura do Projeto

O projeto foi estruturado em 4 camadas principais, seguindo boas práticas de design e separação de preocupações:

1. **API**:  
   - Responsável por receber e gerenciar as requisições dos clientes.  
   - Expõe os endpoints da aplicação e mapeia as solicitações para os serviços da camada `Application`.  
   - Inclui validações iniciais e retorno de respostas padronizadas.

2. **Application**:  
   - Atua como orquestradora da lógica do sistema.  
   - Coordena a interação entre as demais camadas.  
   - Implementa casos de uso específicos, garantindo que cada funcionalidade seja executada de maneira estruturada.  

3. **Domain**:  
   - Contém as regras de negócio e as abstrações centrais da aplicação.  
   - Implementa a lógica que define o funcionamento do sistema, independente de tecnologias externas.  
   - Representa o núcleo do projeto, garantindo consistência e integridade nos processos.

4. **Data**:  
   - Responsável por todas as operações de persistência e recuperação de dados.  
   - Implementa repositórios e métodos que permitem a interação entre a aplicação e os dados armazenados.  

## Como Executar o Projeto

### Pré-requisitos
- .NET SDK 8.0 ou superior
- Banco de dados SQL Server
- Editor de código (ex.: Visual Studio, VS Code)

### Testando o Projeto
Use ferramentas como *Postman* ou *Swagger* para testar as rotas de API (não há interface web implementada).

### 📚 Tecnologias Utilizadas
- **C# e .NET**
- **Entity Framework Core**
- **Banco de Dados SQL Server**
  
