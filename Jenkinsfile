#!/usr/bin/env groovy Jenkinsfile

library 'JenkinsSharedLibraries'

pipeline {
    agent {
        node {
            label 'slave-1'
        }
    }
    environment {
        NUGET_KEY     = credentials('CanalSharp_Nuget_key')
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
                sh "cd docker/aspnetcore2.2;chmod +x build.sh;build.sh"
                echo "success"
            }
        }
        stage('push-image:') {
            steps {
                echo "workspace: "
                sh "pwd"
                echo "success"
            }
        }
    }
}