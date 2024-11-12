import axios from "axios";
const API_BASE_URL = "http://localhost.sportz.io:5117";

export const getAllUsers = async () =>{
    try{
        const response = await axios.get(`${API_BASE_URL}/api/users`);
        if(response.status===200 && response.data){
            return response.data;
        }
    }
    catch(error){
        console.log(error.message);
    }
};

export const addName = async (name) => {
    try{
        //console.log(`Adding name in api service: ${name}`);
        const response = await axios.post(`${API_BASE_URL}/api/users`, 
            { name: name },
            {
                headers: {
                    'Content-Type': 'application/json',
                }
            }
        );
        if(response.status===201 && response.data){
            return response.data;
        }
    }
    catch(error){
        console.log(error.message);
    }
};