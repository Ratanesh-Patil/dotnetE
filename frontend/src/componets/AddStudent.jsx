import axios from 'axios';
import React, { useState } from 'react'

function AddStudent() {
const [student,setStudent]=useState({name:" ",rollno:" ",email:" ",batch:" "});
const url = "http://localhost:5118";

const handlechange=(ev)=>{
    const name=ev.target.name ;
    const value=ev.target.value ;
    setStudent({...student,[name]:value});
}
const Submitdata=(e)=>{
    e.preventDefault();
    console.log((student))
   return( 
  
    axios.post(url+"/Student",(student)).then((result)=>{
        if(result){
            console.log(result.data)
        }
    })
   )
}

  return (
    <div>
        <form onSubmit={Submitdata}>
        <table>
            <tr> Name : <input type="text" name="name" id='name' value={student.name} onChange={handlechange} /></tr>
            <tr> Rollno : <input type="number" name="rollno" id="rollno"  value={student.rollno} onChange={handlechange} /></tr>
            <tr> Email : <input type="text" name="email" id='email'  value={student.email} onChange={handlechange} /></tr>
            <tr> Batch : <input type="text" name="batch" id='batch'  value={student.batch} onChange={handlechange} /></tr>
            <tr><button type='button' name='btn' id='btn' onClick={Submitdata}>Submit</button></tr>
        </table>

        </form>
    </div>
  )
}

export default AddStudent