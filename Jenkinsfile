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
                stage('pull-latest-image:aspnetcore2.2') {
                    steps {
                        sh "docker pull microsoft/dotnet:2.2.0-aspnetcore-runtime"
                    }
                }

                stage('build-image:aspnetcore2.2') {
                    steps {
                        sh "cd docker/aspnetcore2.2;chmod +x build.sh;./build.sh"
                    }
                }

                stage('push-image:aspnetcore2.2') {
                    steps {
                        sh "docker push stulzq/dotnet:2.2.0-aspnetcore-runtime-with-image"
                    }
                }

                post { 
                    success { 
                        echo 'build image stulzq/dotnet:2.2.0-aspnetcore-runtime-with-image success!'
                    }
                    failure { 
                        echo 'build image stulzq/dotnet:2.2.0-aspnetcore-runtime-with-image failure!'
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
}