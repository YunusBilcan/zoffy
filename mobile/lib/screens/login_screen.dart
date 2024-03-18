// screens/login_screen.dart
import 'package:flutter/material.dart';

class LoginScreen extends StatefulWidget {
  @override
  _LoginScreenState createState() => _LoginScreenState();
}

class _LoginScreenState extends State<LoginScreen> {
  final _emailController = TextEditingController();
  final _passwordController = TextEditingController();
  bool _rememberMe = false;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Zoffy'),
        backgroundColor: Colors.transparent,
        elevation: 0,
        centerTitle: true,
      ),
      body: Container(
        decoration: BoxDecoration(
          image: DecorationImage(
            image: AssetImage("lib/assets/login_screen_background.jpg"), 
            fit: BoxFit.cover,
          ),
        ),
        child: Padding(
          padding: EdgeInsets.all(16.0),
          child: Column(
            mainAxisSize: MainAxisSize.min,
            children: <Widget>[
              TextFormField(
                controller: _emailController,
                decoration: InputDecoration(labelText: 'E-posta'),
                keyboardType: TextInputType.emailAddress,
              ),
              TextFormField(
                controller: _passwordController,
                decoration: InputDecoration(
                  labelText: 'Şifre',
                  suffixIcon: IconButton(
                    icon: Icon(Icons.visibility_off),
                    onPressed: () {
                     
                    },
                  ),
                ),
                obscureText: true,
              ),
              Row(
                children: <Widget>[
                  Checkbox(
                    value: _rememberMe,
                    onChanged: (bool? value) {
                      setState(() {
                        _rememberMe = value ?? false;
                      });
                    },
                  ),
                  Text('Giriş Bilgilerimi Kaydet'),
                ],
              ),
              SizedBox(height: 20), 
              ElevatedButton(
                child: Text('Giriş Yap'),
                onPressed: () {
                  
                },
                style: ElevatedButton.styleFrom(
                  foregroundColor: Colors.white,
                  backgroundColor: Colors.blue, 
                  shape: RoundedRectangleBorder(
                    borderRadius: BorderRadius.circular(30.0), 
                  ),
                  padding: EdgeInsets.symmetric(horizontal: 50, vertical: 15), 
                ),
              ),
              TextButton(
                child: Text('Hesap Oluştur'),
                onPressed: () {
                
                },
              ),
            ],
          ),
        ),
      ),
    );
  }
}
