import React from 'react'

export default function Atividade(props) {

    function prioridadeLabel(parem){
        switch(parem){
            case 'Baixa':
            case 'Normal':
            case 'Alta':
              return parem;
            default:
            return 'Não defenida';
        }
    }
    function prioridadeStyle(parem, icone){
        switch(parem){
            case 'Baixa':
              return icone ? 'smile' : 'success';
            case 'Normal':
              return icone ? 'meh' : 'dark';
            case 'Alta':
              return icone ? 'frown' : 'warning';
            default:
              return 'Não defenida';
        }
    }

    return (
    <div className={"card mb-2 shadow-sm border-" + prioridadeStyle(props.ativ.prioridade)}>
            <div className="card-body">
              <div className='d-flex justify-content-between'>
                <h5 className='card-title'>
                  <span className="badge text-bg-secondary me-2 ">{props.ativ.id} </span>
                  {props.ativ.titulo}
                </h5>
                <h6> Prioridade: 
                  <span className={'me-1 text-' + prioridadeStyle(props.ativ.prioridade)}>
                    <i className={`ms-1 me-1 fa-regular fa-face-${prioridadeStyle(props.ativ.prioridade, true)}`}></i>
                    {prioridadeLabel(props.ativ.prioridade)}
                  </span>
                </h6>
              </div>
              <p className="card-text"> {props.ativ.descricao}</p>
              <div className='d-flex  justify-content-end pt-2 m-0 border-top'>
                <button className='btn-sm btn btn-outline-primary me-2'
                  onClick = {() => props.pegarAtividade(props.ativ.id)}>
                  <i className="fas fa-solid fa-pen me-2"></i>
                  Editar
                </button>
                <button className='btn-sm btn btn-outline-danger'
                  onClick = {() => props.handleConfirmeModal(props.ativ.id)}>
                  <i className="fas fa-solid fa-trash me-2"></i>
                  deletar
                </button>
              </div>
            </div>
          </div>
  )
}
