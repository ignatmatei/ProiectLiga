import 'bootstrap/dist/css/bootstrap.css';
import React, { useState } from 'react';
import ReactDOM from 'react-dom/client';
import './index1.css';
function Navbar()
{
    const [count, setCount] = useState(-1);
    if (count == -1){
         return(
            <nav class="navbar navbar-expand-lg navbar-light bg-light fixed-top" >
    <a class="navbar-brand" href="#">
        <img src="imagini/memeit.png" id="NavImg">
            </img>
    </a>
    <div class="collapse navbar-collapse" id="Group4">
        <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#ModalLogin" id="Login">
            Logare
        </button>
        <div class="modal fade" id="ModalLogin" tabindex="-1" role="dialog" aria-labelledby="ModalLoginTitle" aria-hidden="true">
     <div class="modal-dialog modal-dialog-centered" role="document">
      <div class="modal-content">
       <div class="modal-header" id="HeaderLogin">
        <img src="imagini/memeit.png" id="ImgLogin">
        </img>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close" id="CloseLogin">
          <span aria-hidden="true">&times;</span>
        </button>
        </div>
        <div class="modal-body" id="BodyLogin">
           <div id="BoxLogin">
            <p id="WelcomeLogin">
              Welcome back 
            </p>
            <p id="UsernameLogin">
             Username
            </p>
            <form>
              <input type="text" id="FormUserLogin" name="Userlogin">
             </input>  
            </form>
           <p id ="PasswordLogin">
           Parolă
           </p>
           <form>
            <input type="text" id="FormPassLogin" name="Passlogin">
            </input>
           </form> 
           </div>
        </div>
        </div>
          </div>
     </div>
        <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#ModalCreare" id="Creare">
            Creare cont
        </button>
     <div class="modal fade" id="ModalCreare" tabindex="-1" role="dialog" aria-labelledby="ModalLCreareTitle" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header" id="HeaderRegister">
                  <img src="imagini/memeit.png" id="ImgRegister">
                  </img>
                  <button type="button" class="close" data-dismiss="modal" aria-label="Close" id="CloseRegister">
                   <span aria-hidden="true">&times;</span>
                  </button>
                </div>
                <div class="modal-body" id="BodyRegister">
                    <div id="BoxRegister">
                        <p id="WelcomeRegister">
                         Welcome
                        </p>
                        <p id="UsernameRegister">
                         Username
                        </p>
                        <form>
                        <input type="text" id="FormUserRegister" name="UserRegister">
                        </input>
                        </form>
                        <p id="EmailRegister">
                        Email
                        </p>
                        <form>
                        <input type="text" id="FormEmailRegister" name="EmailRegister">
                        </input>
                        </form>
                        <p id="PasswordRegister">
                        Parolă   
                        </p>
                        <form>
                        <input type="text" id="FormPassRegister" name="PassRegister">
                        </input>
                        </form>
                    </div>
                </div>
            </div>
        </div>
     </div>   
    </div>
    </nav>     
    );
    }
}