import 'package:flutter/material.dart';

class LoginScreen extends StatefulWidget {
  @override
  _LoginScreenState createState() => _LoginScreenState();
}

class _LoginScreenState extends State<LoginScreen> {
  final _usernameController = TextEditingController();
  final _passwordController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Stack(
        children: [
          Container(
            decoration: BoxDecoration(
              image: DecorationImage(
                image: AssetImage('lib/assets/login_screen_background.jpg'),
                fit: BoxFit.cover,
              ),
            ),
          ),
          Positioned(
            top: MediaQuery.of(context).padding.top, 
            right: 16.0,
            child: IconButton(
              icon: Icon(Icons.notification_add_sharp, color: Colors.white, size: 30.0), 
              onPressed: () {
                
              },
            ),
          ),
          Padding(
            padding: const EdgeInsets.all(16.0),
            child: Column(
              mainAxisSize: MainAxisSize.min,
              children: <Widget>[
                Spacer(),
                Text(
                  'Zoffy',
                  style: TextStyle(
                    fontSize: 36.0,
                    fontWeight: FontWeight.bold,
                    color: Color.fromARGB(255, 17, 0, 201),
                  ),
                ),
                SizedBox(height: 48.0), 
                _buildTextField(_usernameController, 'Kullanıcı Adı'),
                SizedBox(height: 16.0),
                _buildTextField(_passwordController, 'Şifre', isPassword: true),
                SizedBox(height: 24.0),
                _buildLoginButton(),
                _buildFlatButton('Şifremi Unuttum', onTap: () {
                 
                }),
                Spacer(),
              ],
            ),
          ),
        ],
      ),
    );
  }


  Widget _buildTextField(TextEditingController controller, String label, {bool isPassword = false}) {
    return TextField(
      controller: controller,
      obscureText: isPassword,
      decoration: InputDecoration(
        hintText: label,
        filled: true,
        fillColor: Colors.grey[200],
        border: OutlineInputBorder(
          borderRadius: BorderRadius.circular(12.0),
          borderSide: BorderSide.none,
        ),
        contentPadding: EdgeInsets.symmetric(horizontal: 20.0),
      ),
      style: TextStyle(fontSize: 16.0),
    );
  }

  Widget _buildLoginButton() {
    return ElevatedButton(
      onPressed: () {
        // 
      },
      child: Text('Giriş Yap'),
      style: ElevatedButton.styleFrom(
        foregroundColor: Colors.white,
        backgroundColor: Color.fromARGB(255, 17, 0, 201), 
        minimumSize: Size(double.infinity, 50), 
        shape: RoundedRectangleBorder(
          borderRadius: BorderRadius.circular(12.0), 
        ),
        elevation: 0,
        padding: EdgeInsets.symmetric(vertical: 12.0),
      ),
    );
  }

  Widget _buildFlatButton(String text, {required VoidCallback onTap}) {
    return TextButton(
      onPressed: onTap,
      child: Text(
        text,
        style: TextStyle(
          color: Color.fromARGB(255, 17, 0, 201), 
          fontWeight: FontWeight.bold,
        ),
      ),
    );
  }
}
