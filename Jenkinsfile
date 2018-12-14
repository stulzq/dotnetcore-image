#!/usr/bin/env groovy Jenkinsfile

library 'JenkinsSharedLibraries'

pipeline {
    agent {
        node {
            label 'slave-1'
        }
    }
    environment {
        DOCKER_LOGIN     = credentials('docker_login')
    }
    triggers {
      githubPush()
    }
    stages {
        stage('pull-latest-image') {
            steps {
                sh "docker pull microsoft/dotnet:2.2.0-aspnetcore-runtime"
                echo "success"
            }
        }
        stage('build-image') {
            steps {
                sh "cd docker/aspnetcore2.2;chmod +x build.sh;./build.sh"
                echo "success"
            }
        }
        stage('push-image') {
            steps {
                sh "docker login $DOCKER_LOGIN"
                sh "docker logout"
            }
        }
        stage('clear') {
            steps {
                sh "history -c"
                sh "echo > $HOME/.bash_history"
            }
        }
    }
}