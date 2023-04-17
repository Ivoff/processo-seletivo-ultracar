# Ideia inicial

## Planos funcionais
* Dados relativos a atores da aplicação são predefinidos, isso permite que eu não me importe com o desenvolvimento de funcionalidades que recebam inputs do usuário e gerem dados relevantes no domínio da aplicação. Exemplo: login com usuário e senha, cadastro de carros, cadastro de ferramentas.
* Planejo dividir a aplicação em dois ou mais projetos, um para o frontend e outro para o backend, a comunicação entre os dois se dará por chamadas http em apis rest.
* Planejo garantir a identificação na comunicação entre frontend e backend, já que é apenas um teste em ambiente controlado e o único input do usuário será um conjunto selecionado de peças já persistidas no banco, não preciso me preocupar com autenticar cada requisição mas sim com a identidade de quem as faz (garantir que um cliente não possa ver o estado do conserto de outro cliente).
* A troca de mensagens entre aplicações será assinada usando JWT (Json Web Token), apesar de não encriptar os dados, permite saber se algo foi modificado. Isso torna o acesso indevido a informações de outro cliente impossível.

## Planos não funcionais 
* 