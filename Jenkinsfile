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
        stage('build-image:2.2.0-aspnetcore-runtime-with-image') {
            steps {
                sh "cd docker/aspnetcore2.2;chmod +x build.sh"
                sh "./build.sh"
                echo "build image success"
                sh "cd $WORKSPACE"
            }
        }
        stage('push-image:') {
            steps {
                echo "push image success"
            }
        }
    }
}