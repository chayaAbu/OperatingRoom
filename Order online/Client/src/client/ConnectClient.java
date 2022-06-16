/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package client;

import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.net.Socket;
import java.util.ArrayList;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author student
 */
public class ConnectClient {

    private  ObjectOutputStream toServer;
    private  DataInputStream fromServer;

    private Socket socket;

    public ConnectClient() {

        try {
            // Create a socket to connect to the server
            socket = new Socket("localhost", 4500);

     // Create an output stream to send data 
            // to the server
            toServer = new ObjectOutputStream(socket.getOutputStream());

  // Create an input stream to receive data
            // from the server
            fromServer = new DataInputStream(socket.getInputStream());

        } catch (IOException ex) {
             Logger.getLogger(ConnectClient.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    public void writeToServer(ArrayList<Spice> s) {
        try {
            toServer.writeObject(s);
            toServer.flush();

        } catch (IOException e) {
            e.printStackTrace();
        }
    }
    
       public String readsFromServer() {
      
           

        try {
            return fromServer.readUTF();
        } catch (IOException ex) {
            Logger.getLogger(ConnectClient.class.getName()).log(Level.SEVERE, null, ex);
        }
            
       
        return null;
       }
    

//    public Spice readFromServer() {
//        try {
//            try {
//
//                return (Spice) fromServer.readObject();
//            } catch (ClassNotFoundException e) {
//                // TODO Auto-generated catch block
//                e.printStackTrace();
//            }
//        } catch (IOException e) {
//            e.printStackTrace();
//        }
//        return null;
//    }

//    public static void main(String[] args) {
//        new ConnectClient();
//       
//       // incoming.close();
//
//    }
//}
   
}