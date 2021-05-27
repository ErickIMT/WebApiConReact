import './App.css';
import { useEffect, useState } from 'react';
import axios from 'axios';
import 'bootstrap/dist/css/bootstrap.min.css';
import { Label, Modal, ModalBody, ModalFooter, ModalHeader } from 'reactstrap';

function App() {
  const urlPaises = "https://localhost:44393/api/WebApi/paises";
  const urlGeneros = "https://localhost:44393/api/WebApi/generos";
  const urlCantantes = "https://localhost:44393/api/WebApi/cantantes";
  const urlAlbumes = "https://localhost:44393/api/WebApi/albums";
  const urlPPD = "https://localhost:44393/api/WebApi";
  //Guardar data de Consultas
  const [data, setData] = useState([]);

  //Metodos Get
  const getAlbums = async() =>{
    await axios.get(urlAlbumes).then(response =>{
      setData(response.data);
    }).catch(error =>{
      console.log(error);
    })
  }

  const[paises, setPaises] = useState([]);
  const getPaises = async() =>{
    await axios.get(urlPaises).then(response =>{
      setPaises(response.data);
    }).catch(error =>{
      console.log(error);
    })
  }

  const[generos, setGeneros] = useState([]);
  const getGeneros = async() =>{
    await axios.get(urlGeneros).then(response =>{
      setGeneros(response.data);
    }).catch(error =>{
      console.log(error);
    })
  }

  const[cantantes, setCantantes] = useState([]);
  const getCantantes = async() =>{
    await axios.get(urlCantantes).then(response =>{
      setCantantes(response.data);
    }).catch(error =>{
      console.log(error);
    })
  }

  //Metodo Post

  const solicitudPost = async () =>{
    album.stock = parseInt(album.stock);
    album.precio = parseFloat(album.precio);
    await axios.post(urlPPD,album).then(response =>{
      setData(data.concat(response.data));      
    }).catch(error =>{
      console.log(error);
    })
    abrirCerrarModal();
    getAlbums();
  }

  //Metodo Put

  const solicitudPut = async () =>{
    await axios.put(urlPPD+"/"+album.albumId, album).then(response =>{
      setData(data.concat(response.data));
    }).catch(error =>{
      console.log(error);
    })
    abrirCerrarModalEditar();
    getAlbums();
  }

  //Metodo Delete

  const solicitudDelete = async() =>{
    await axios.delete(urlPPD+"/"+album.albumId).then(response =>{
      setData(data.filter(item => item.albumId!==response.data));
      
    }).catch(error =>{
      console.log(error);
    })
    abrirCerrarModalEliminar();
    getAlbums();   
  }

  //Constantes de manejo de estados booleanos
  const [modalInsertar, setMoldalInsertar] = useState(false);
  const [modalEditar, setMoldalEditar] = useState(false);
  const [modalEliminar, setMoldalEliminar] = useState(false);

  const [album, setAlbum] = useState({
    albumId:'',
    albumTit:'',
    albumFech:'',
    cantanteId:'',
    cantanteName:'',
    paisId:'',
    paisNom:'',
    generoId:'',
    generoNom:'',
    precio:0,
    tipo:'',
    stock:0
  });

  const handleChange=(e) =>{
    const {name, value} = e.target;
    setAlbum({
      ...albun,[name]:value
    });
  }

  const abrirCerrarModalEditar = () =>{
    setMoldalEditar(!modalEditar);
  }

  const abrirCerrarModalEliminar = () =>{
    setMoldalEliminar(!modalEliminar);
  }

  const seleccionarAlbum = (album, caso) =>{
    //guardar el albun Seleccionado
    setAlbum(album);
    (caso === "Editar")? abrirCerrarModalEditar(): abrirCerrarModalEliminar();
  }

  const abrirCerrarModal = () =>{
    setMoldalInsertar(!modalInsertar);
  }

  useEffect(()=>{
    getAlbums();
    getCantantes();
    getGeneros();
    getPaises();
  },[])

  return (
    <div className="App">
      <br/>
      <button className="btn btn-success mb-3" onClick={()=>abrirCerrarModal()}>Nuevo Album</button>
      <br/>
      <table className="table table-light table-hover">
        <thead>
          <tr>
            <th>Album Id</th>
            <th>Titulo Album</th>
            <th>Fecha Album</th>
            <th>Cantante Id</th>
            <th>Nombre Cantante</th>
            <th>Pais Id</th>
            <th>Pais Nombre</th>
            <th>Genero Id</th>
            <th>Genero Nombre</th>
            <th>Precio</th>
            <th>Tipo</th>
            <th>Stock</th>
          </tr>
        </thead>
        <tbody>
          {data.map(item =>(
            <tr key={item.albumId}>
              <td>{item.albumTit}</td>
              <td>{item.albumFech}</td>
              <td>{item.cantanteId}</td>
              <td>{item.cantanteName}</td>
              <td>{item.paisId}</td>
              <td>{item.paisNom}</td>
              <td>{item.generoId}</td>
              <td>{item.generoNom}</td>
              <td>{item.precio}</td>
              <td>{item.tipo}</td>
              <td>{item.stock}</td>
              <td>
                <button className="btn btn-primary" onClick={()=>seleccionarAlbum(item,"Editar")}>Editar</button>{"|"}
                <button className="btn btn-danger" onClick={()=>seleccionarAlbum(item,"Eliminar")}>Eliminar</button>
              </td>
            </tr>
          ))}          
        </tbody>
      </table>

      {/*Formulario Modal*/}
      <Modal isOpen={modalInsertar}>
        <ModalHeader>Crear Album</ModalHeader>
        <ModalBody>
          <div className="form-group">
            <Label>Album ID:</Label>
            <input type="text" className="form-control" name="albumId" onChange={handleChange}/>
            <br/>

            <Label>Titulo de Album:</Label>
            <input type="text" className="form-control" name="albumTit" onChange={handleChange}/>
            <br/>

            <Label>Fecha de Album:</Label>
            <input type="date" className="form-control" name="albumFech" onChange={handleChange}/>
            <br/>

            <Label>Cantante:</Label>
            <select name="cantanteId" className="form-control" onChange={handleChange}>
              <option>Seleccionar...</option>
            {cantantes.map(item =>(
              <option key={item.cantanteId} value={item.cantanteId}>{item.cantanteName}</option>
            ))}
            </select>
            <br/>

            <Label>Pais:</Label>
            <select name="paisId" className="form-control" onChange={handleChange}>
              <option>Seleccionar...</option>
            {paises.map(item =>(
              <option key={item.paisId} value={item.paisId}>{item.pais_Nom}</option>
            ))}
            </select>
            <br/>

            <Label>Genero:</Label>
            <select name="generoId" className="form-control" onChange={handleChange}>
              <option>Seleccionar...</option>
            {generos.map(item =>(
              <option key={item.generoId} value={item.generoId}>{item.generoName}</option>
            ))}
            </select>
            <br/>

            <Label>Precio:</Label>
            <input type="text" className="form-control" name="precio" onChange={handleChange}/>
            <br/>

            <Label>Tipo: </Label>
            <input type="text" className="form-control" name="tipo" onChange={handleChange}/>
            <br/>

            <Label>Stock: </Label>
            <input type="text" className="form-control" name="stock" onChange={handleChange}/>
            <br/>
          </div>
        </ModalBody>
        <ModalFooter>
          <button className="btn btn-info" onClick={solicitudPost}>Guardar</button>{"|"}
          <button className="btn btn-danger" onClick={()=>abrirCerrarModal()}>Cancelar</button>
        </ModalFooter>
      </Modal>

      <Modal isOpen={modalEditar}>
        <ModalHeader>Actualizar Album</ModalHeader>
        <ModalBody>
        <div className="form-group">
            <Label>Album ID:</Label>
            <input type="text" className="form-control" name="albumId" readOnly value={album.albumId} onChange={handleChange}/>
            <br/>

            <Label>Titulo de Album:</Label>
            <input type="text" className="form-control" name="albunTit" value={albun.albunTit} onChange={handleChange}/>
            <br/>

            <Label>Fecha de Album:</Label>
            <input type="date" className="form-control" name="albumFech" value={album.albumFech} onChange={handleChange}/>
            <br/>

            <Label>Cantante:</Label>
            <select name="cantanteId" className="form-control" defaultValue={albun.cantanteId} onChange={handleChange}>
              <option>Seleccionar...</option>
            {cantantes.map(item =>(
              <option key={item.cantanteId} value={item.cantanteId}>{item.cantanteName}</option>
            ))}
            </select>
            <br/>

            <Label>Pais:</Label>
            <select name="paisId" className="form-control" defaultValue={albun.paisId} onChange={handleChange}>
              <option>Seleccionar...</option>
            {paises.map(item =>(
              <option key={item.paisId} value={item.paisId}>{item.pais_Nom}</option>
            ))}
            </select>
            <br/>

            <Label>Genero:</Label>
            <select name="generoId" className="form-control" defaultValue={albun.generoId} onChange={handleChange}>
              <option>Seleccionar...</option>
            {generos.map(item =>(
              <option key={item.generoId} value={item.generoId}>{item.generoName}</option>
            ))}
            </select>
            <br/>

            <Label>Precio:</Label>
            <input type="text" className="form-control" name="precio" value={albun.precio} onChange={handleChange}/>
            <br/>

            <Label>Tipo: </Label>
            <input type="text" className="form-control" name="tipo" value={albun.tipo} onChange={handleChange}/>
            <br/>

            <Label>Stock: </Label>
            <input type="text" className="form-control" name="stock" value={albun.stock} onChange={handleChange}/>
            <br/>
          </div>
        </ModalBody>
        <ModalFooter>
          <button className="btn btn-info" onClick={solicitudPut}>Guardar</button>{"|"}
          <button className="btn btn-danger" onClick={()=>abrirCerrarModalEditar()}>Cancelar</button>
        </ModalFooter>

      </Modal>
      <Modal isOpen={modalEliminar}>
        <ModalHeader>Eliminar Albun</ModalHeader>
        <ModalBody>
          Estas Seguro de Eliminar el Albun {album.albumTit}
        </ModalBody>
        <ModalFooter>
          <button className="btn btn-danger" onClick={solicitudDelete}>Eliminar</button>
          <button className="btn btn-secondary" onClick={()=>abrirCerrarModalEliminar()}>Cancelar</button>
        </ModalFooter>
      </Modal>
    </div>
  );  
} 

export default App;
