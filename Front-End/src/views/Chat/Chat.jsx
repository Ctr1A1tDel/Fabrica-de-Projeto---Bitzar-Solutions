import { useRef, useState } from 'react'

import { Box, Grid } from '@mui/material'
import { FormProvider, useForm } from 'react-hook-form'
import Chart from 'react-apexcharts'

import {
  AttachedItems,
  ChatMessages,
  InputContainer,
  MainBox,
  MainContainer,
  PromptField,
} from './components'

// Mock Data para testes
const incomingChartComponent = (
  <Chart
    options={{
      chart: {
        id: 'ia-generated-bar',
        theme: { mode: 'dark' },
        background: 'transparent',
      },
      xaxis: { categories: ['Jan', 'Fev', 'Mar', 'Abr'] },
      colors: ['#00E39E'],
    }}
    series={[{ name: 'Performance', data: [44, 55, 41, 67] }]}
    type="bar"
    width="100%"
  />
)

const Chat = () => {
  // Mock Data para testes
  const [chatHistory] = useState([
    { role: 'user', content: 'Olá, gere um gráfico de performance deste ano.' },
    { role: 'ia', content: 'Claro! Aqui estão os dados processados:' },
    {
      role: 'ia',
      content: incomingChartComponent,
    },
    { role: 'ia', content: 'Espero que isso ajude na sua análise.' },
  ])

  const fileInputRef = useRef(null)

  const formMethods = useForm({
    defaultValues: { files: [], prompt: '' },
  })

  const onAttachClick = () => fileInputRef.current.click()

  return (
    <MainContainer>
      <MainBox>
        <Grid
          container
          sx={{
            width: '100%',
            maxWidth: '80%',
            flexDirection: 'column',
            gap: 2,
          }}
        >
          <ChatMessages chatHistory={chatHistory} />
        </Grid>
      </MainBox>

      <Box
        sx={{
          p: 2,
          width: '100%',
          display: 'flex',
          justifyContent: 'center',
        }}
      >
        <InputContainer>
          <FormProvider {...formMethods}>
            <AttachedItems fileInputRef={fileInputRef} />

            <PromptField onAttachClick={onAttachClick} />
          </FormProvider>
        </InputContainer>
      </Box>
    </MainContainer>
  )
}

export default Chat
