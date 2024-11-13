import React from 'react'
import Atividade from './Atividade';

export default function AtividadeLista(props) {
  return (
    <div className='mt-3'>
        {props.atividades.map((ativ) => (
        
          <Atividade    
          key={ativ.id}
          ativ = {ativ} //atividades = {props.atividades} como eu tinha feito e deu um erro enorme  
          deletarAtividade = {props.deletarAtividade}          
          pegarAtividade = {props.pegarAtividade}
          />
        ))}
      </div>
  )
}
//mostrar pro meu pai significadfo do hook e pedir pra ele traduzir 