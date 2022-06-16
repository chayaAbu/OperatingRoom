package server;

import client.Spice;
import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.io.PrintWriter;
import java.net.Socket;
import java.util.ArrayList;
import java.util.Date;
import java.util.logging.Level;
import java.util.logging.Logger;
import static server.ConectServer.ifQtY;

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
/**
 *
 * @author student
 */
public class ClientHedler extends Thread {
    Socket client;
     ObjectInputStream in;
     DataOutputStream out;

    public ClientHedler(Socket soc) {
        this.client =client;
          try {
            in=new ObjectInputStream(soc.getInputStream()); 
            out=new DataOutputStream(soc.getOutputStream());
        } catch (IOException ex) {
            Logger.getLogger(ClientHedler.class.getName()).log(Level.SEVERE, null, ex);
        }
      
           
            start();
    }

         public void run() {
         ArrayList<Spice>  read;
        try {
             try {
                 read = (ArrayList<Spice> )in.readObject();
                 boolean hasEnoufh=ifQtY(read);
                 //החזרת הודעה ללקוח אם ההזמנה הצליחה או לא
                 if(hasEnoufh==true){
                     System.out.println("you succed");
                     out.writeUTF("you succed");
                 }
                 else{
                     System.out.println("you failed");
                     out.writeUTF("you failed");
                 }
             } catch (ClassNotFoundException ex) {
                 Logger.getLogger(ClientHedler.class.getName()).log(Level.SEVERE, null, ex);
             }
           // System.out.println(read);

      //  out.writeUTF("i connect with you " + read);
        } catch (IOException ex) {
            Logger.getLogger(ClientHedler.class.getName()).log(Level.SEVERE, null, ex);
        }

        
    }

        
        
        
    
   
}

