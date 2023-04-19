# Ideia inicial
* Dados relativos a atores da aplicação são predefinidos, isso permite que eu não me importe com o desenvolvimento de funcionalidades que recebam inputs do usuário e gerem dados relevantes no domínio da aplicação. Exemplo: login com usuário e senha, cadastro de carros, cadastro de ferramentas.
* Planejo dividir a aplicação em dois ou mais projetos, um para o frontend e outro para o backend, a comunicação entre os dois se dará por chamadas http em apis.
* Planejo garantir a identificação na comunicação entre frontend e backend, já que é apenas um teste em ambiente controlado e o único input do usuário será um conjunto selecionado de peças já persistidas no banco, não preciso me preocupar com autenticar cada requisição mas sim com a identidade de quem as faz (garantir que um cliente não possa ver o estado do conserto de outro cliente).
* Planejo utilizar aspectos do DDD, não irei usar apropriadamente por completo por limitações de tempo.
* A troca de mensagens entre aplicações será assinada usando JWT (Json Web Token), apesar de não encriptar os dados, permite saber se algo foi modificado. Isso torna o acesso indevido a informações de outro cliente impossível.
---
* QrCode
    * O cliente terá um qrcode por carro cadastrado
    * O qrcode será gerado a partir do Id do cliente e o Id do carro
    * O cliente, supostamente logado, terá acesso a uma tela onde o qrcode do carro selecionado irá ser exibido

## Fluxos da aplicação

### Colaborador inicia um serviço
* O cliente acessa a aplicação web para exibir o qrcode na tela do celular
* O colaborador abre a applicação web para escanear o código na tela do celular do cliente
* O colaborador inicia o serviço.

### Cliente exibe Qrcode
* O cliente acessa a aplicação web selecionando um carro dos cadastrados
* O cliente acessa a página de exibição do qrcode

# Mudanças - 1
* Nada de codificação da comunicação em JWT, não há tempo.

# Mudanças - 2
* Ia colocar uma propriedade de cor a entidade carro da seção da aplicação destinada ao cliente, porém acabei esquecendo e nhá mais tempo.

# Mudanças - 3
* Modelei "Parts", quantity não deveria estar na tabela e entidade concreta de Parts. Tive que passar zero na hora de ler as peças pela identidade delas e não da instância delas em um serviço.

# Mudanças - 4
* Não dá tempo de implementar a remoção de peças então a aplicação não suportará essa funcionalidade.
