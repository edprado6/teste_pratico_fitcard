# Teste prático Fitcard

<b>Sistema de cadastros de Estabelecimentos Comerciais</b>

O sistema permite:

- Gerenciamento de Categorias de estabelecimentos comerciais (cadastro, edição, listagem, visualização de detalhes e exclusão). O sistema não permite a inserção de registros com mesmo nome. Caso aconteça tentativa de inserção de categorias com mesmo nome, a categoria previamente cadastrada é atualizada. 
- Gerenciamento de Estabelecimentos comerciais (cadastro, edição, listagem, visualização de detalhes e exclusão). O sistema não permite a inserção de registros com mesmo CNPJ. Caso aconteça tentativa de inserção de estabelecimentos com mesmo nome, o estabelecimento previamente cadastrado é atualizado.

<b>Tecnologias</b>

- Banco de dados MySQL.
- Net Core com C#
- Net MVC (camada de apresentação)
- Web Api 
- Swagger (documentação da Web Api)
- Fluent Validation (validação server side)
- Entity Framework (ORM)
- jQuery (validação client side)

<b>Estrutura</b>

- Dominio: representação da modelagem do DB e filtros customizados para cada entidade.
- DominioViewModel: representação da modelagem do DB e filtros customizados para cada entidade, mas que só pode ser vista pelas camadas de apresentação. As especificações das validações server-side são realizadas aqui.
- Infra: helpers que podem ser usados por qualquer método de qualquer outra camada.
- Repositorio: camada de acesso ao DB. Deve ser vista apenas pela camada de serviços.
- Servico: regras de negócio e outros serviços externos (WSCorreios, por exemplo).
- Web Api: disponibilização dos serviços web.
- UI: interface gráfica web. Consome os serviços disponibilizados pela Web Api possibilitando interação com usuário.

<b>Melhorias</b>

- Disponibilização de filtros na camada de apresentação (UI). Os campos e botões apresentados ainda não possuem ação. Os métodos de listagem da Web Api já contemplam essa melhoria e podem ser testados na interface gráfica da documentação Swagger.
- Paginação nas grids da camada de apresentação. Os métodos de listagem da Web Api já possuem essa melhoria. O número de registros exibidos nas grids estão limitados a 30 registros.
- Exclusão lógica dos registros. A flag "Excluido" recebe valor "true" e o campo "DataExclusao" recebe a data atual. Esses registros não deverão ser exibidos em pesquisas. A modelagem já contempla os campos necessários, mas a exclusão ainda não foi implementada. 


<b>Fontes:</b>

Teste prático:<br>
https://fitcard.github.io/


Validação de CNPJ:<br>
http://www.macoratti.net/11/09/c_val1.htm

Validações customizadas usando Fluent Validation: <br>
http://netcoders.com.br/validando-dados-com-fluent-validation/
