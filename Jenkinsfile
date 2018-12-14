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

        stage('docker-login') {
            steps {
                sh "docker login $DOCKER_LOGIN"
            }
        }

        stage('build-image:aspnetcore2.2') {
            stages {
                stage('pull-latest-image') {
                    steps {
                        sh "docker pull microsoft/dotnet:2.2.0-aspnetcore-runtime"
                    }
                }

                stage('build-image') {
                    steps {
                        sh "cd docker/aspnetcore2.2;chmod +x build.sh;./build.sh"
                    }
                }

                stage('push-image') {
                    steps {
                        sh "docker push stulzq/dotnet:2.2.0-aspnetcore-runtime-with-image"
                    }
                }
            }
        }

        stage('docker-logout') {
            steps {
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