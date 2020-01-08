provider "aws" {
  region = "us-east-1"
}

resource "aws_instance" "angular-yja" {
  ami           = "ami-0eb5acb649e8c4020"
  instance_type = "t2.micro"
  key_name      = "yja-test"

  tags {
    Name = "angular"
  }

  provisioner "remote-exec" {
    connection {
      type        = "ssh"
      user        = "ubuntu"
      private_key = "${file("yja-test.pem")}"
    }

    inline = [
      ". ~/.nvm/nvm.sh",
      "nvm install 11.6.0",
      "nvm alias default 11.6.0",
      "cd /home/ubuntu/ShoppingWebsiteAngular",
      "npm install -g @angular/cli@latest",
      "npm install --save-dev @angular/cli@latest",
      "npm install",
      "ng serve --host 0.0.0.0"
    ]
  }
}
